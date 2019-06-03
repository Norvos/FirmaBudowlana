import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { RouterModule } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { OrdersComponent } from './orders/orders.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';
import { WorkerListComponent } from './worker-list/worker-list.component';
import { NewOrderComponent } from './newOrder/newOrder.component';

import { AuthGuard } from './_guards/auth.guard';

import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { AdminService } from './_services/admin.service';

import { appRoutes } from './routes';


export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      OrdersComponent,
      NewOrderComponent,
      AdminMenuComponent,
      WorkerListComponent
   ],
   imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      BsDropdownModule.forRoot(),
      ReactiveFormsModule,
      JwtModule.forRoot({
         config: {
            tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/account']
         }
      }),
      RouterModule.forRoot(appRoutes),
      BsDatepickerModule.forRoot()
   ],
   providers: [
      AuthService,
      AlertifyService,
      AdminService,
      AuthGuard
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }