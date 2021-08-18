import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "@app/core/guards/auth.guard";
import { HouseComponent } from "./house/house.component";

import { SampleComponent } from "./sample/sample.component";

const routes: Routes = [
    {
        path: "sample",
        component: SampleComponent,
        canActivate: [AuthGuard]
    },
    {
        path: "house",
        component: HouseComponent,
        canActivate: [AuthGuard]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FeaturesRoutingModule { }
