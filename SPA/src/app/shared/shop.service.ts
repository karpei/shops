import { Injectable } from '@angular/core';
import { Shop} from './shop.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
  list:Shop[];
  constructor(private http:HttpClient) { }
  ShopsList(){
    this.http.get(environment.ApiBaseURL+"shops").toPromise().then(res=>this.list=res as Shop[]);
  }
}
