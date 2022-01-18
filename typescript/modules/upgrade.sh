cd ..

npx create-nx-workspace@latest allors --preset=empty --cli=nx --nx-cloud=false

cd allors

npm install -D jest-chain
npm install -D jest-trx-results-processor
npm install -D @nrwl/angular

npm install @angular/cdk
npm install @angular/material
npm install @angular/material-luxon-adapter
npm install bootstrap@4.6.0
npm install common-tags
npm install cross-fetch
npm install date-fns
npm install easymde
npm install jsnlog
npm install luxon

// Extranet
npx nx g @nrwl/angular:application angular/apps/extranet --routing=true --style=scss --e2eTestRunner=none
npx nx g @nrwl/workspace:library workspace/angular/apps/extranet
npx nx g @nrwl/workspace:library workspace/derivations/apps/extranet
npx nx g @nrwl/workspace:library workspace/derivations/apps/extranet-custom
npx nx g @nrwl/workspace:library workspace/domain/apps/extranet
npx nx g @nrwl/workspace:library workspace/meta/apps/extranet
npx nx g @nrwl/workspace:library workspace/meta/json/apps/extranet

// Intranet
npx nx g @nrwl/angular:application angular/apps/intranet --routing=true --style=scss --e2eTestRunner=none
npx nx g @nrwl/workspace:library workspace/angular/apps/intranet
npx nx g @nrwl/workspace:library workspace/derivations/apps/intranet
npx nx g @nrwl/workspace:library workspace/derivations/apps/intranet-custom
npx nx g @nrwl/workspace:library workspace/derivations/apps/intranet-tests
npx nx g @nrwl/workspace:library workspace/domain/apps/intranet
npx nx g @nrwl/workspace:library workspace/meta/apps/intranet
npx nx g @nrwl/workspace:library workspace/meta/json/apps/intranet

// Base
npx nx g @nrwl/angular:application angular/base/app --routing=true --style=scss --e2eTestRunner=none
npx nx g @nrwl/workspace:library workspace/angular/base
npx nx g @nrwl/workspace:library workspace/angular-material/base
npx nx g @nrwl/workspace:library workspace/derivations/base
npx nx g @nrwl/workspace:library workspace/derivations/base-custom
npx nx g @nrwl/workspace:library workspace/domain/base
npx nx g @nrwl/workspace:library workspace/meta/base
npx nx g @nrwl/workspace:library workspace/meta/core
npx nx g @nrwl/workspace:library workspace/meta/json/base

// Core
npx nx g @nrwl/angular:application angular/core/app --routing=true --style=scss --e2eTestRunner=none
npx nx g @nrwl/workspace:library workspace/angular/core
npx nx g @nrwl/workspace:library workspace/derivations/core
npx nx g @nrwl/workspace:library workspace/derivations/core-custom
npx nx g @nrwl/workspace:library workspace/domain/core
npx nx g @nrwl/workspace:library workspace/meta/json/core

// System
npx nx g @nrwl/workspace:library protocol/json/system

npx nx g @nrwl/workspace:library workspace/adapters/json/system
npx nx g @nrwl/workspace:library workspace/adapters/json/system-tests
npx nx g @nrwl/workspace:library workspace/adapters/system
npx nx g @nrwl/workspace:library workspace/adapters/system-tests

npx nx g @nrwl/workspace:library workspace/derivations/system
npx nx g @nrwl/workspace:library workspace/domain/system

npx nx g @nrwl/workspace:library workspace/meta/json/system
npx nx g @nrwl/workspace:library workspace/meta/json/system-tests
npx nx g @nrwl/workspace:library workspace/meta/system
npx nx g @nrwl/workspace:library workspace/meta/system-tests