import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ShopsComponent } from './shops/shops.component';
import { ItemsComponent } from './items/items.component';
import { ItemsListComponent } from './items/items-list/items-list.component';
import { ItemComponent } from './items/item/item.component';
import { FormsModule } from '@angular/forms'

const appRoutes: Routes =[
  { path: '', component: ShopsComponent},
  { path: 'shop/:id', component: ItemsComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    ShopsComponent,
    ItemsComponent,
    ItemsListComponent,
    ItemComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
