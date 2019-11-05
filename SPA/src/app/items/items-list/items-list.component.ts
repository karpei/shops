import { Component, OnInit } from '@angular/core';
import { ItemService } from 'src/app/shared/item.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-items-list',
  templateUrl: './items-list.component.html',
  styleUrls: ['./items-list.component.css']
})
export class ItemsListComponent implements OnInit {
  id:Number;
  constructor(private activateRoute: ActivatedRoute,private service:ItemService) { 
    this.id = activateRoute.snapshot.params['id'];
  }

  ngOnInit() {
    this.service.ItemsList(this.id);
  }
  updateItem(item){
    this.service.FormData = Object.assign({},item);
  }
  deleteItem(id:Number){
    if(confirm("Delete this Item?")){
    this.service.deleteItem(id).subscribe(res=>{
      this.service.ItemsList(this.id);
    })
  }

  }
}
