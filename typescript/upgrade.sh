cd ..

npx create-nx-workspace@latest allors --preset=empty --cli=nx --nx-cloud=false

cd allors

rem npm install -D @nrwl/angular
npm install -D jest-chain
npm install -D jest-extended
npm install -D jest-trx-results-processor

npx nx g @nrwl/workspace:library protocol/json/system

npx nx g @nrwl/workspace:library workspace/adapters/json/system
npx nx g @nrwl/workspace:library workspace/adapters/json/system-tests

npx nx g @nrwl/workspace:library workspace/domain/core
npx nx g @nrwl/workspace:library workspace/domain/core-custom
npx nx g @nrwl/workspace:library workspace/domain/core-generated
npx nx g @nrwl/workspace:library workspace/domain/core-tests
npx nx g @nrwl/workspace:library workspace/domain/system

npx nx g @nrwl/workspace:library workspace/meta/core
npx nx g @nrwl/workspace:library workspace/meta/core-generated
npx nx g @nrwl/workspace:library workspace/meta/core-tests
npx nx g @nrwl/workspace:library workspace/meta/lazy/system
npx nx g @nrwl/workspace:library workspace/meta/lazy/system-tests
npx nx g @nrwl/workspace:library workspace/meta/system