import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shared/shop.service';

@Component({
  selector: 'app-shops',
  templateUrl: './shops.component.html',
  styleUrls: ['./shops.component.css']
})
export class ShopsComponent implements OnInit {

  constructor(private service:ShopService) { }

  ngOnInit() {
    this.service.ShopsList();
  }

}
