export enum Status {
  Active= 1,
  Inactive= 0,
  Delete= 3,
}
export enum ChallanType {
  Delivery=1,
  Receive=2,
  DeliveryReturn=3,
  ReceiveReturn=4,
  Transfer=5,
  Menufecturing=6,
  Consumption=7,
  WReceive=8,
}
export enum InvoiceType {
  Sales = 7,
  SalesReturn = 8,
  Purchase = 10,
  PurchaseReturn = 11,
}
export enum ProductUnitType {
  Default,
  ChallanUnit,
  BillUnit,
  Book
}
export enum OrderType {
  Sales = 7,
  Purchase = 10,
  SalesQuote=11,
  PurchaseQuote=12,

}