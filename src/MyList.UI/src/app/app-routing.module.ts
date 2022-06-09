import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from "./_guards/auth.guard";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
          // { path: 'login', component: LoginComponent },
          // { path: 'members/:id', component: MemberDetailComponent },
          // { path: 'lists', component: ListsComponent },
          // { path: 'messages', component: MessagesComponent },
      ]
  },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
