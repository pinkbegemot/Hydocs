import React from 'react';
import ReactDom from 'react-dom';
import App  from './App';
ReactDom.render(<App />, document.getElementById('content'));
var div = $(".ContactView-title");
$(div).fadeOut();
$(div).fadeIn(3500, "linear", null);