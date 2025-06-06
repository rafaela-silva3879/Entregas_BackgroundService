using Microsoft.Extensions.Options;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Subscriber.Settings;
using Newtonsoft.Json;
using System.Text;
using Entregas_WorkerService.Service.Models.Payloads;
using System.Diagnostics;
using Entregas_WorkerService.Application.Interfaces;
using Entregas_WorkerService.Application.Commands;

public class PedidosConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IOptions<MessageBrokerSettings> _messageBrokerSettings;
    private IConnection? _connection;
    private IModel? _model;

    public PedidosConsumer(IServiceProvider serviceProvider,
                           IOptions<MessageBrokerSettings> messageBrokerSettings)
    {
        _serviceProvider = serviceProvider;
        _messageBrokerSettings = messageBrokerSettings;

        var factory = new ConnectionFactory
        {
            Uri = new Uri(_messageBrokerSettings.Value.Url)
        };
        _connection = factory.CreateConnection();
        _model = _connection.CreateModel();
        _model.QueueDeclare(
            queue: _messageBrokerSettings.Value.Queue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_model);
        consumer.Received += Consumer_Received;

        _model.BasicConsume(
            queue: _messageBrokerSettings.Value.Queue,
            autoAck: false,
            consumer: consumer);

        return Task.CompletedTask;
    }

    private async void Consumer_Received(object sender, BasicDeliverEventArgs args)
    {
        try
        {
            var contentArray = args.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(contentArray);

            Debug.WriteLine($"[RabbitMQ] Mensagem recebida: {contentString}");

            var payload = JsonConvert.DeserializeObject<PedidoPayloadModel>(contentString);

            if (payload?.DetalhesPedido == null)
            {
                Debug.WriteLine("[RabbitMQ] Detalhes do pedido ausentes ou inválidos.");
                _model.BasicAck(args.DeliveryTag, false);
                return;
            }

            using var scope = _serviceProvider.CreateScope();

            var pedidoAppService = scope.ServiceProvider.GetRequiredService<IPedidoAppService>();

            var command = new PedidoSaiuPraEntregaCommand
            {
                PedidoId = payload.DetalhesPedido.PedidoId
            };

            await pedidoAppService.UpdateStatus(command);

            Debug.WriteLine($"[Processamento] Pedido {command.PedidoId} processado com sucesso.");

            _model.BasicAck(args.DeliveryTag, false);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[Erro] Falha ao processar mensagem: {ex.Message}");
        }
    }

}
