import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from "./_guards/auth.guard";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { MainGameComponent } from './Categories/Game/MainPage/main-game/main-game.component';
import { SoloGameComponent } from './Categories/Game/SoloPage/solo-game/solo-game.component';
import { CreateGameComponent } from './Categories/Game/create-game/create-game.component';


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
          { path: 'game/createGame', component: CreateGameComponent },
          { path: 'game/soloGame', component: SoloGameComponent },
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
