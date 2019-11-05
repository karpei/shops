export class Item{
    id:Number;
    name:String;
    description:String;
    shopId:Number;
}
export class Shop {
    id:Number;
    name:String;
    adress:String;
    wHours:String;
    items:Item[];
}
