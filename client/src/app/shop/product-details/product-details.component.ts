import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  productDetail: IProduct;

  constructor(private shopService: ShopService, private routeParam: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct(+this.routeParam.snapshot.paramMap.get('id'));
  }

  loadProduct(id: number){
    this.shopService.getProduct(id).subscribe(
      response => {
        this.productDetail = response;
      }
    );
  }

}
