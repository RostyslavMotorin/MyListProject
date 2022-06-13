import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AppRoutingModule } from './app-routing.module';
import { ParamsModel } from './_models/params.model';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { HomeComponent } from './home/home.component';
import { MainGameComponent } from './Categories/Game/MainPage/main-game/main-game.component';
import { SoloGameComponent } from './Categories/Game/SoloPage/solo-game/solo-game.component';
import { CreateGameComponent } from './Categories/Game/create-game/create-game.component';
import { UploadComponent } from './Categories/upload/upload.component';
import { ItemComponent } from './Categories/item/item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    MainGameComponent,
    SoloGameComponent,
    CreateGameComponent,
    UploadComponent,
    ItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    NgMultiSelectDropDownModule.forRoot(),
    BsDropdownModule.forRoot()
  ],
  providers: [ParamsModel],
  bootstrap: [AppComponent]
})
export class AppModule { }
