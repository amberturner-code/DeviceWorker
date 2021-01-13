# DeviceWorker

This is a .NET Core Web API service that does not expose any endpoints. It runs a background service that "listens" for device assignment messages using RabbitMQ as a message broker.
It then publishes a message through the broker to indicate that the assignment is complete.

<b>To install RabbitMQ:</b></br>
https://www.rabbitmq.com/download.html

<b>To run RabbitMQ locally in a Docker container, run these commands in Powershell:</b>

docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=password rabbitmq:3-management

docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

Navigate to http://localhost:15672 to open the RabbitMQ Management UI and view the queues.

Errors and informational messages for this service are written to a log file here: <b>%appdata%/Devices/logs</b>

