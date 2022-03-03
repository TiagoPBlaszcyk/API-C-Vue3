export class Person {
  public id?: number | null
  public name: string
  public whatsApp: number
  public email: string | null
  public cpf: string | null

  constructor(
    id = null,
    name,
    whatsApp,
    email = null,
    cpf = null,
  ) {
    this.id = id
    this.name = name
    this.whatsApp = whatsApp
    this.email = email
    this.cpf = cpf
  }
}