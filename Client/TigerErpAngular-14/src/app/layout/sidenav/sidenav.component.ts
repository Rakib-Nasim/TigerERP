import { Component, HostBinding, HostListener, Input, OnInit } from '@angular/core';
import { Router, UrlTree } from '@angular/router';

import { ModulesModel } from 'src/app/models/ModulesModel';
import { ModulesService } from './../../services/Settings/modules.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
 orientation = 'vertical';
companyName: string="Tiger-Erp"
@Input() moduleId = -1;
@Input() orientations:string;
lstModulesModel:ModulesModel = new ModulesModel();

@HostBinding('class.layout-sidenav') private hostClassVertical = false;
  @HostBinding('class.layout-sidenav-horizontal') private hostClassHorizontal = false;
  @HostBinding('class.flex-grow-0') private hostClassFlex = false;

  public innerWidth: any;
  @HostListener('window:load', ['$event'])
  onResize() {
    this.innerWidth = window.innerWidth;
  }
// lstModulesModels:ModulesModel[]=[];

   pageList:any[]=[{"name":"Author","pageRoutePath":"author-entry"},
   {"name":"Publisher","pageRoutePath":"publisher-entry"},
   {"name":"Category","pageRoutePath":"category-entry"},
   {"name":"Godown","pageRoutePath":"godown-entry"},
   {"name":"Unit","pageRoutePath":"unit-setup"},
   {"name":"Module","pageRoutePath":"modules"},
   {"name":"Receive Chalan","pageRoutePath":"receive-chalan"},
   {"name":"Book-Entry","pageRoutePath":"book-entry"}
  ]
    sunModuleList:any[]=[{"name":"settings","moduleRoutePath":"settings"},

  ]
  
   constructor(private router: Router,private _moduleService:ModulesService) { 
        this.hostClassHorizontal = !this.hostClassVertical;
        this.hostClassFlex = this.hostClassHorizontal;
   }

  ngOnInit(): void
   {
     // TODO document why this method 'ngOnInit' is empty
     this.getSubModuleWithPage();
    //  this.getAllModules();
   }

  // getAllModules() {
  //   this._moduleService.getAllModules().subscribe(res => {
  //     this.lstModulesModels = (res as ModulesModel[]).filter(m=>m.parentModuleId==0);

  //   });
  // }
  
  getSubModuleWithPage() {
    this._moduleService.getSubModuleWithPage(1,202,1,this.moduleId).subscribe(res => {
      // this.lstModulesModel = res as ModulesModel[];
        this.lstModulesModel = (res as ModulesModel[])[0];
      console.log("user",this.lstModulesModel);
    });
  }

  //   getClasses() {
  //   let bg = 

  //   if (this.orientation === 'horizontal' && (bg.indexOf(' sidenav-dark') !== -1 || bg.indexOf(' sidenav-light') !== -1)) {
  //     bg = bg
  //       .replace(' sidenav-dark', '')
  //       .replace(' sidenav-light', '')
  //       .replace('-darker', '')
  //       .replace('-dark', '');
  //   }
  // }


  isActive(url:string) {
     return this.router.navigate([url,String]);     
  }

  isMenuActive(url:any) {
    return this.router.isActive(url, false);
  }

  isMenuOpen(url:any) {
    return this.router.isActive(url, false) && this.orientation !== 'horizontal';
  }

  // toggleSidenav() {
  //   this.layoutService.toggleCollapsed();
  // }



}
