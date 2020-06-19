import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';


const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'} },
  {path: 'notfound', component: NotFoundComponent, data: {breadcrumb: 'Not found'}},
  {path: 'servererror', component: ServerErrorComponent, data: {breadcrumb: 'Server Error'}},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(module => module.ShopModule),
  data: {breadcrumb: 'Shop'}},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
