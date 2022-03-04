export class Person {
  public id?: number | undefined
  public name: string
  public email: string
  public senha: string
  public permissao: string
  public cpf: string
  public whatsApp: number

  constructor(
    id = undefined,
    name,
    email,
    senha,
    permissao,
    cpf,
    whatsApp,
  ) {
    this.id = id
    this.name = name
    this.email = email
    this.senha = senha
    this.permissao = permissao
    this.cpf = cpf
    this.whatsApp = whatsApp
  }
}