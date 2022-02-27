export class Product {
  public id?: number | undefined
  public name: string | null
  public price: number | null
  public description: string | null
  public categoryName: string | null
  public imageUrl: string | null

  constructor(
    id = undefined,
    name = '',
    price = 0,
    description = '',
    categoryName = '',
    imageUrl = ''
  ) {
    this.id = id
    this.name = name
    this.price = price
    this.description = description
    this.categoryName = categoryName
    this.imageUrl = imageUrl
  }
}
