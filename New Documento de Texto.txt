## Entregas_WorkerService
Descrição
Este projeto é um serviço em segundo plano (Background Service) desenvolvido em .NET 7 que faz parte do sistema Entregas. Ele consome mensagens enviadas pela API principal via RabbitMQ para processar o status das entregas de forma assíncrona.

## Funcionalidade
Escuta a fila do RabbitMQ para receber eventos de novas entregas cadastradas.
Processa cada entrega atualizando seu status conforme regras de negócio.
Simula o fluxo de entregas (saindo para entrega, entrega concluída com sucesso ou falha).

## Relação com o projeto Entregas
Este serviço funciona em conjunto com o projeto Entregas, que é responsável por cadastrar entregas, salvar os dados no banco e enviar mensagens para o RabbitMQ. O Entregas_WorkerService consome essas mensagens para realizar o processamento em background.

## Requisitos
.NET SDK 7.0 ou superior
RabbitMQ instalado e configurado (mesmo servidor utilizado pelo projeto Entregas)

## Como executar
1 - Clone este repositório.
2 - Configure o arquivo appsettings.json com as informações do RabbitMQ (mesmas configurações do projeto Entregas).
3 - Execute o projeto para iniciar o serviço de processamento.

