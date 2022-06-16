import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from "./_guards/auth.guard";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { MainGameComponent } from './Categories/Game/MainPage/main-game/main-game.component';
import { SoloGameComponent } from './Categories/Game/SoloPage/solo-game/solo-game.component';
import { CreateGameComponent } from './Categories/Game/create-game/create-game.component';
import { SoloFilmComponent } from './Categories/Film/SoloPage/solo-film/solo-film.component';
import { MainFilmComponent } from './Categories/Film/MainPage/main-film/main-film.component';
import { CreateFilmComponent } from './Categories/Film/create-film/create-film.component';
import { MainSerialComponent } from './Categories/Serial/MainPage/main-serial/main-serial.component';
import { SoloSerialComponent } from './Categories/Serial/SoloPage/solo-serial/solo-serial.component';
import { CreateSerialComponent } from './Categories/Serial/create-serial/create-serial.component';
import { MainAnimeComponent } from './Categories/Anime/MainPage/main-anime/main-anime.component';
import { SoloAnimeComponent } from './Categories/Anime/SoloPage/solo-anime/solo-anime.component';
import { CreateAnimeComponent } from './Categories/Anime/create-anime/create-anime.component';
import { MainBookComponent } from './Categories/Book/MainPage/main-book/main-book.component';
import { SoloBookComponent } from './Categories/Book/SoloPage/solo-book/solo-book.component';
import { CreateBookComponent } from './Categories/Book/create-book/create-book.component';
import { ProfileComponent } from './profile/profile.component';
import { CollectionComponent } from './Collection/collection/collection.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
          { path: 'game/mainGame', component: MainGameComponent },
          { path: 'game/soloGame', component: SoloGameComponent },
          { path: 'game/createGame', component: CreateGameComponent },
          { path: 'film/mainFilm', component: MainFilmComponent },
          { path: 'film/soloFilm', component: SoloFilmComponent },
          { path: 'film/createFilm', component: CreateFilmComponent },
          { path: 'serial/mainSerial', component: MainSerialComponent },
          { path: 'serial/soloSerial', component: SoloSerialComponent},
          { path: 'serial/createSerial', component: CreateSerialComponent },
          { path: 'anime/mainAnime', component: MainAnimeComponent },
          { path: 'anime/soloAnime', component: SoloAnimeComponent },
          { path: 'anime/createAnime', component: CreateAnimeComponent },
          { path: 'book/mainBook', component: MainBookComponent },
          { path: 'book/soloBook', component: SoloBookComponent },
          { path: 'book/createBook', component: CreateBookComponent },

          { path: 'profile', component: ProfileComponent },
          { path: 'collection', component: CollectionComponent },
      ]
  },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  
 }
