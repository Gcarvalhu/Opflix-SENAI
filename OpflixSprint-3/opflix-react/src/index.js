import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';


//importar suas páginas
import App from './pages/home/App';
import Login from './pages/login/Login';

//importando o React-router-dom
import { Route, Link, BrowserRouter as Router, Switch, Redirect } from "react-router-dom";

import * as serviceWorker from './serviceWorker';
import Lancamentos from './pages/lancamentos/lancamentos';
import Cadastro from './pages/cadastro/Cadastro';
import Categorias from './pages/categorias/categorias';

const RotaPrivada = ({ component: Component}) => (
    <Route
        render={props =>
            localStorage.getItem("usuario-opflix") !== null ?
            (
                <Component {...props}/>
            ) : (
                <Redirect
                    to={{ pathname: "/login", state: { from: props.location} }}
                />
            )
        }
    />
)

const routing = (
    <Router>
    <div>
        <Switch>
            <Route exact path='/' component={App} />
            <Route path='/login' component={Login}/>
            <RotaPrivada path= '/lancamentos' component={Lancamentos}/>
            <Route path='/cadastro' component={Cadastro}/>
            <RotaPrivada path='/categorias' component={Categorias}/>
        </Switch>
    </div>
    </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
