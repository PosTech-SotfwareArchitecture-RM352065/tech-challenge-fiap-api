Funcionalidade: Cadastro de produtos

	Como administrador do resturante
	Eu quero adicionar um novo produto no cardápio
	Para que os clientes possam adicionar esse novo produto no pedido

Cenário: Adicionar um novo produto no cardápio
	Dado temos um novo "Lanche" chamado "Mega Lanche" com a descrição de "Nosso mega lanche" e com preço de 15,99
	Quando adicionar o novo lanche no cardápio
	Então deve retornar o novo código cadastrado

Cenário: Adicionar um produto já existente no cardápio 
	Dado temos um lanche chamado "Mega Lanche" já cadastrado
	Quando adicionar o lanche existente no cardápio
	Então deve retornar erro informando a duplicidade

Cenário: Adicionar um novo produto com descrição inválida
	Dado temos um novo "Lanche" chamado "Mega Lanche" com a descrição de vazia e com preço de 15,99
	Quando adicionar o novo lanche no cardápio
	Então deve retornar erro informando a descrição inválida