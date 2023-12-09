Funcionalidade: Atualização de produtos

	Como administrador do resturante
	Eu quero alterar e remover produto no cardápio
	Para que os clientes possam adicionar esse produto no pedido com os novos dados

Cenário: Remover um produto no cardápio
	Dado não vamos mais oferecer lanche chamado "Mega Lanche"
	Quando remover o lanche do cardapio
	Então deve retornar o produto como inativo

Cenário: Atualizar o preço do produto
	Dado um lanche já existente chamado "Mega Lanche"
	Quando for informado o código e o novo preço 29,99
	Então deve retornar que a operação foi finalizada com sucesso

Cenário: Atualizar o preço inválido
	Dado um lanche já existente chamado "Mega Lanche"
	Quando for informado o código e um novo preço -0,10
	Então deve retornar erro informando o preço inválido