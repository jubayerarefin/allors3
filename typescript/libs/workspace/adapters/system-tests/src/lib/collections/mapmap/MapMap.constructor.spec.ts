import { MapMap, Numbers } from '@allors/workspace/adapters/system';

describe('MapMap', () => {
  describe('after construction', () => {
    const mapMap = new MapMap<string, string, Numbers>();

    it('should be defined', () => {
      expect(mapMap).toBeDefined();
    });
  });
});