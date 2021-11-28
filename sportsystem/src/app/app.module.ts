import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Vartotojo
import { LoginComponent } from './Pages/General/login/login.component';
import { RegisterComponent } from './Pages/General/register/register.component';
import { EditAccountComponent } from './Pages/General/edit-account/edit-account.component';
import { BalanceComponent } from './Pages/General/balance/balance.component';
import { GymComponent } from './Pages/General/gym/gym.component';
import { PassportComponent } from './Pages/General/passport/passport.component';

//Parduotuves
import { ShopComponent } from './Pages/Kestutis/shop/shop.component';
import { CartComponent } from './Pages/Kestutis/cart/cart.component';
import { PaymentComponent } from './Pages/Kestutis/payment/payment.component';
import { AddItemComponent } from './Pages/Kestutis/add-item/add-item.component';
import { ItemComponent } from './Pages/Kestutis/item/item.component';

//Prenumeratos
import { SubscriptionComponent } from './Pages/Robertas/subscription/subscription.component';
import { SubCancelComponent } from './Pages/Robertas/sub-cancel/sub-cancel.component';
import { SubExtendComponent } from './Pages/Robertas/sub-extend/sub-extend.component';
import { SubCreateComponent } from './Pages/Robertas/sub-create/sub-create.component';
import { SubTransferComponent } from './Pages/Robertas/sub-transfer/sub-transfer.component';
import { SubPauseComponent } from './Pages/Robertas/sub-pause/sub-pause.component';

//Treniruotes
import { WorkoutComponent } from './Pages/Dainius/workout/workout.component';
import { WorkoutDetailsComponent } from './Pages/Dainius/workout-details/workout-details.component';
import { WorkoutRegisterComponent } from './Pages/Dainius/workout-register/workout-register.component';
import { WorkoutCalendarComponent } from './Pages/Dainius/workout-calendar/workout-calendar.component';

// angular material
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { HomeComponent } from './Pages/General/home/home.component';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ShopComponent,
    RegisterComponent,
    HomeComponent,
    CartComponent,
    PaymentComponent,
    AddItemComponent,
    ItemComponent,
    EditAccountComponent,
    BalanceComponent,
    GymComponent,
    PassportComponent,
    SubscriptionComponent,
    SubCancelComponent,
    SubExtendComponent,
    SubCreateComponent,
    SubTransferComponent,
    SubPauseComponent,
    WorkoutComponent,
    WorkoutDetailsComponent,
    WorkoutRegisterComponent,
    WorkoutCalendarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
