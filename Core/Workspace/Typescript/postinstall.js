#! /usr/bin/env node

const path = require('path');
const lnk = require('lnk');

function link(src, dst){
    const basename = path.basename(src);

    lnk([src], dst)
    .then(() => console.log(basename + ' linked') )
    .catch((e) =>  e.errno && e.errno != -4075 ? console.log(e) : console.log('already linked'))
}

link ('../../../System/Workspace/Typescript/libs/data/system/src', 'libs/data/system');
link ('../../../System/Workspace/Typescript/libs/meta/system/src', 'libs/meta/system');
link ('../../../System/Workspace/Typescript/libs/protocol/system/src', 'libs/protocol/system');

link ('../../../System/Workspace/Typescript/libs/workspace/system/src', 'libs/workspace/system');
link ('../../../System/Workspace/Typescript/libs/workspace/memory/src', 'libs/workspace/memory');
