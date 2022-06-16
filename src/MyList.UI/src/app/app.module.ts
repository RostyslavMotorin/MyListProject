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
import { MainSerialComponent } from './Categories/Serial/MainPage/main-serial/main-serial.component';
import { SoloSerialComponent } from './Categories/Serial/SoloPage/solo-serial/solo-serial.component';
import { CreateSerialComponent } from './Categories/Serial/create-serial/create-serial.component';
import { MainAnimeComponent } from './Categories/Anime/MainPage/main-anime/main-anime.component';
import { SoloAnimeComponent } from './Categories/Anime/SoloPage/solo-anime/solo-anime.component';
import { CreateAnimeComponent } from './Categories/Anime/create-anime/create-anime.component';
import { MainBookComponent } from './Categories/Book/MainPage/main-book/main-book.component';
import { SoloBookComponent } from './Categories/Book/SoloPage/solo-book/solo-book.component';
import { CreateBookComponent } from './Categories/Book/create-book/create-book.component';
import { MainFilmComponent } from './Categories/Film/MainPage/main-film/main-film.component';
import { SoloFilmComponent } from './Categories/Film/SoloPage/solo-film/solo-film.component';
import { CreateFilmComponent } from './Categories/Film/create-film/create-film.component';
import { CollectionComponent } from './Collection/collection/collection.component';
import { ProfileComponent } from './profile/profile.component';

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
    ItemComponent,
    MainSerialComponent,
    SoloSerialComponent,
    CreateSerialComponent,
    MainAnimeComponent,
    SoloAnimeComponent,
    CreateAnimeComponent,
    MainBookComponent,
    SoloBookComponent,
    CreateBookComponent,
    MainFilmComponent,
    SoloFilmComponent,
    CreateFilmComponent,
    CollectionComponent,
    ProfileComponent,
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
