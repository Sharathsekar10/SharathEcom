import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productbrands';
import { IProductTypes } from '../shared/models/producttypes';
import { ShopParams } from '../shared/models/shopParams';


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('search', {static: true}) searchTerm: ElementRef;
  products: IProduct[];
  productBrands: IProductBrand[];
  productTypes: IProductTypes[];
  shopParams = new ShopParams();
  totalCount: number;
  sortList = [{name : 'Alphapetical', value : 'name'},
              {name : 'Price Low to High', value : 'priceAsc'},
              {name : 'Price High to Low', value : 'priceDesc'}];
  constructor(private shopservice: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts(){
    this.shopservice.getProducts(this.shopParams).subscribe(
      response => {
        this.products = response.data;
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error => {
        console.log(error);
      }
    );
  }

  getBrands(){
    this.shopservice.getBrands().subscribe(
      response => {
        this.productBrands = [{id: 0, name: 'All'}, ...response];
      },
      error => {
        console.log(error);
      }
    );
  }

  getTypes(){
    this.shopservice.getTypes().subscribe(
      response => {
        this.productTypes =  [{id: 0, name: 'All'}, ...response];
      },
      error => {
        console.log(error);
      }
    );
  }

  onBrandSelected(brandId: number){
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sortBy: string){
    this.shopParams.sort = sortBy;
    this.getProducts();
  }

  onPageChanged(event: any){
    if (this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch(){
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.getProducts();
    // this.shopParams.search = '';
  }

  onReset(){
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
