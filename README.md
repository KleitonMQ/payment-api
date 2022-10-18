## TESTE TÉCNICO BOOTCAMP POTTENCIAL .NET DEVELOPER

API REST construída utilizando .Net.

<img src="src/Screenshots/Swagger.png" alt="Homme do Swagger.">
<img src="src/Screenshots/Schema.png" alt="Schema da API.">

- A API possui 3 operações:
1) Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
<img src="src/Screenshots/Post.png" alt="Registro de venda.">

2) Buscar venda: Busca pelo Id da venda;
<img src="src/Screenshots/searchID.png" alt="Pesquisa por id.">

3) Atualizar venda: Permite que seja atualizado o status da venda.
<img src="src/Screenshots/PutStatus.png" alt="Atualização da venda.">

* OBS.: Possíveis status: `Pagamento aprovado` | `Enviado para transportadora` | `Entregue` | `Cancelada`.

<img src="src/Screenshots/PutStatusError.png" alt="Registro de venda.">
