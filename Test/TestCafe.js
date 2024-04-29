const {Selector} = require("testcafe");
const { RequestHook } = require('testcafe');

class ProtocolSwitchHook extends RequestHook {
  constructor () {
    super();
  }

  async onRequest (event) {
    if (event.requestOptions.protocol === 'https:') {
      event.requestOptions.protocol = 'http:';
    }
  }

  async onResponse () {
    // No response processing needed.
  }
}

const protocolSwitchHook = new ProtocolSwitchHook();


fixture('Getting Started').page('http://144.91.64.53:8081/').requestHooks(protocolSwitchHook);
//fixture('Getting Started').page('http://localhost:4200/');

test('Testing of testCafe', async  t =>
{
  //Constanter til dropdown 1

  const H1 = Selector('#h1-1') //Her vælges h1

    await t

    //input
      .typeText('#input1','Jens Jensen')
      .typeText('#input2','Jensen vej 1')
      .typeText('#input3','1000')
      .typeText('#input4','Jensby')



      //Click
      .click('#button1')
      .wait(2000)


      .expect(H1.textContent).eql('Saved name is: Jens Jensen') //Her testes om værdien i paragraf er Tekst1

});



//kør testen
//testcafe chrome TestCafe.js --live
//Ctrl+S stopper testen
//Ctrl+r genstarter testen

