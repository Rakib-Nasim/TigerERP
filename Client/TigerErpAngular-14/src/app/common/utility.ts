import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class Utility {
    // tslint:disable-next-line:ban-types
    enumToArray(enums: any): Object[] {
        const StringIsNumber = (value: any) => isNaN(Number(value)) === false;
        return Object.keys(enums).filter(StringIsNumber)
          .map(key => ({ key: key, value: enums[key] }));
      }
}