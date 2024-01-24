

export interface IUserCadastro {
  nome: string;
  sobrenome: string;
  dataNascimento: string; // Ou você pode usar o tipo Date
  rg: string;
  cpf: string;
  estado: string;
  cidade: string;
  cep: string;
  logradouro: string;
  complemento: string;
  numero: number;
  email: string;
  telefoneCelular: string;
  username: string;
  senha: string;
}


export interface IUserEdit {
  pessoaId: number
  nome: string;
  sobrenome: string;
  rg: string;
  cpf: string;
  dataNascimento: Date | null; // Ou você pode usar o tipo Date
}
