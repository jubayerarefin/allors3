module.exports = {
  name: 'domain-custom',
  preset: '../../../jest.config.js',
  globals: {
    'ts-jest': {
      tsConfig: '<rootDir>/tsconfig.spec.json',
    },
  },
  transform: {
    '^.+\\.[tj]sx?$': 'ts-jest',
  },
  moduleFileExtensions: ['ts', 'tsx', 'js', 'jsx'],
  coverageDirectory: '../../../coverage/libs/domain/custom',
  reporters: [
    'default',
    [
      'jest-trx-results-processor',
      {
        outputFile: '../../../artifacts/tests/domain.trx',
      },
    ],
  ],
};