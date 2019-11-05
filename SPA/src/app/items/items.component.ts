import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../shared/shop.service';
import { ItemService } from '../shared/item.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  id: number;
  constructor(private activateRoute: ActivatedRoute,private service:ItemService){
       
      this.id = activateRoute.snapshot.params['id'];
  }

  ngOnInit() {
    this.service.ItemsList(this.id);
  }

}
