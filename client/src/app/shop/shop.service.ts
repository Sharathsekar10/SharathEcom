import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IProductBrand } from '../shared/models/productbrands';
import { IProductTypes } from '../shared/models/producttypes';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';
  constructor(private httpclient: HttpClient) { }

  getProducts(shopParams: ShopParams){
    let params = new HttpParams();
    if (shopParams.brandId !== 0){
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId !== 0){
      params = params.append('typeId', shopParams.typeId.toString());
    }
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());
    if (shopParams.search){
      params = params.append('search', shopParams.search);
    }
    return this.httpclient.get<IPagination>(this.baseUrl + 'products', {params});
  }

  getProduct(id: number){
    return this.httpclient.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  getBrands(){
    return this.httpclient.get<IProductBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes(){
    return this.httpclient.get<IProductTypes[]>(this.baseUrl + 'products/types');
  }
}
