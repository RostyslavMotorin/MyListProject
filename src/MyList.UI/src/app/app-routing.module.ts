import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from "./_guards/auth.guard";
import { HomeComponent } from "./home/home.component";


const routes: Routes = [
  { path: '', component: HomeComponent },
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
          // { path: 'members', component: MemberListComponent },
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
