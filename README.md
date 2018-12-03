# SLMM 

This reference application mimics the architecture suggested in the document <a href='https://aka.ms/microservicesebook'>.Net Microservices Architecture for Containerized .Net Applications </a>.

<p>The architecture proposes a service oriented implementation with multiple autonomous .NET Core microservices (each one owning its own data/db) and implementing CQRS pattern.
Supports asynchronous communication for data updates propagation across multiple services using RabbitMQ.