export class Person {
  public id?: number | undefined
  public name: string | null
  public whatsApp: number | null
  public email: string | null
  public cpf: string | null
  public imageUrl: string | null

  constructor(
    id = undefined,
    name = '',
    whatsApp = 0,
    email = '',
    cpf = '',
    imageUrl = ''
  ) {
    this.id = id
    this.name = name
    this.whatsApp = whatsApp
    this.email = email
    this.cpf = cpf
    this.imageUrl = imageUrl
  }
}