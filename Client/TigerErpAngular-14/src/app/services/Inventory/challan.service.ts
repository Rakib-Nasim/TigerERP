import { ChallanType } from 'src/app/common/projectEnum';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChallanService {
  baseApiUrl: string =environment.apiUrl+'/api/Inventory/Challan/';

  constructor(private http:HttpClient) { }
  getChallanNoByComp(compId:number,branchId:number,challanType:ChallanType){
    return this.http.get(this.baseApiUrl+'GetChallanNoByComp/compId/'+compId+'/branchId/'+branchId+'/challanType/'+challanType);
  }

  getFormattedChallanNo(date: Date, challanType: ChallanType, challanNo: number): string {
    let formattedChallanNo: string = this.getChallanTypeKey(challanType);
    formattedChallanNo += date.getFullYear().toString().substring(2, 4);
    formattedChallanNo += '-' + (date.getMonth() + 1).toString().padStart(2, '0') + '-';
    formattedChallanNo += challanNo ? challanNo.toString().padStart(4, '0') : '0000';
    return formattedChallanNo;
  }

  getChallanTypeKey(challanType: ChallanType): string {

    let challanKey: string;
    switch (challanType) {
      case ChallanType.Delivery:
        challanKey = 'DC';
        break;
      case ChallanType.Receive:
        challanKey = 'RC';
        break;
      case ChallanType.DeliveryReturn:
        challanKey = 'RC';
        break;
      case ChallanType.ReceiveReturn:
        challanKey = 'DC';
        break;
      case ChallanType.Transfer:
        challanKey = 'TC';
        break;
        case ChallanType.Menufecturing:
        challanKey = 'MC';
        break;
        case ChallanType.Consumption:
          challanKey = 'CM';
          break;
          case ChallanType.WReceive:
            challanKey = 'WR';
            break;
      default:
        return '';
    }
    return challanKey;

  }

}
