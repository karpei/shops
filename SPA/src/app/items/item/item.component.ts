import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ItemService } from 'src/app/shared/item.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  id:Number;
  constructor(private activateRoute: ActivatedRoute,private service:ItemService) {
    this.id = activateRoute.snapshot.params['id'];
   }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(Form?:NgForm){
    if(Form!=null)
    Form.resetForm();
    this.service.FormData = {
      id:null,
      name:'',
      description:'',
      shopId:this.id
    }
  }
  newItem(){
    this.resetForm();
  }
  UpdateItem(){
    if(this.service.FormData.id){
      this.service.UpdateItem().subscribe(res=>{
        this.resetForm();
        this.service.ItemsList(this.id);
      })
    }else{
      this.service.AddItem().subscribe(res=>{
        this.resetForm();
        this.service.ItemsList(this.id);
      })
    }
  }
}
