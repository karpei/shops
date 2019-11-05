import { Injectable } from '@angular/core';
import { Shop, Item} from './shop.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ItemService {
  ShopItems:Shop;
  FormData:Item;
  
  constructor(private http:HttpClient) { }

  ItemsList(id:Number){
    this.http.get(environment.ApiBaseURL+"shops/"+id).toPromise().then(res=>this.ShopItems=res as Shop);
  }
  deleteItem(id:Number){
    return this.http.delete(environment.ApiBaseURL+"items/"+id)
  }
  UpdateItem(){
    return this.http.put(environment.ApiBaseURL+"items/"+this.FormData.id,this.FormData)
  }
  AddItem(){
    const postData = {
      name:this.FormData.name,
      description:this.FormData.description,
      shopId:this.FormData.shopId
    }
    return this.http.post(environment.ApiBaseURL+"items/",postData)
  }
}
