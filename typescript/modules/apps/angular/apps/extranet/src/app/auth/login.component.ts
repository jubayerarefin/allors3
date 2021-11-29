import { Component, OnDestroy, Self } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { of, Subscription } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

import { ContextService } from '@allors/workspace/angular/core';
import { M } from '@allors/workspace/meta/default';
import { Singleton } from '@allors/workspace/domain/default';
import { IPullResult } from '@allors/workspace/domain/system';
import { AuthenticationService, SingletonId, TestScope } from '@allors/workspace/angular/base';

@Component({
  templateUrl: './login.component.html',
  providers: [ContextService],
})
export class LoginComponent extends TestScope implements OnDestroy {
  public loginForm = this.formBuilder.group({
    password: ['', Validators.required],
    userName: ['', Validators.required],
  });

  subscription: Subscription;
  m: M;

  constructor(@Self() private allors: ContextService, private authService: AuthenticationService, private singletonId: SingletonId, private router: Router, public formBuilder: FormBuilder) {
    super();

    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;
  }

  public login() {
    const userName = this.loginForm.controls.userName.value;
    const password = this.loginForm.controls.password.value;

    if (this.subscription) {
      this.subscription.unsubscribe();
    }

    this.subscription = this.authService
      .login$(userName, password)
      .pipe(
        switchMap((result) => {
          if (result.a) {
            const m = this.m;
            const { pullBuilder: pull } = m;

            const pulls = [
              pull.Singleton({}),
              pull.Person({
                objectId: result.u,
              }),
            ];

            return this.allors.context.pull(pulls).pipe(
              map((loaded: IPullResult) => {
                const singletons = loaded.collection<Singleton>(m.Singleton);
                this.singletonId.value = singletons[0].id;

                return { init: true };
              })
            );
          } else {
            return of({ init: false });
          }
        })
      )
      .subscribe(
        ({ init }) => {
          if (init) {
            this.router.navigate(['/']);
          } else {
            alert('Could not log in');
          }
        },
        (error) => alert(JSON.stringify(error))
      );
  }

  public ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
