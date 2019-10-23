import React, { Component } from 'react';

import Axios from 'axios';
import { Link } from "react-router-dom";

import '../../assets/css/login.css';
export default class Login extends Component {
    constructor() {
        super();
        this.state = {
            email: "",
            senha: "",
        }
    }

    //Atribuir valor ao Email
    setarEstadoEmail = (event) => {
        this.setState({ email: event.target.value })
        console.log({ email: event.target.value })

    }

    //Atribuir valor a Senha
    setarEstadoSenha = (event) => {
        this.setState({ senha: event.target.value })
        console.log({ senha: event.target.value })
    }

    fazerLogin = (event) => {
        event.preventDefault();
        Axios.post("http://localhost:5000/api/Login",
            {
                email: this.state.email,
                senha: this.state.senha
            })
            .then(data => {
                if (data.status === 200) {
                    localStorage.setItem("usuario-opflix", data.data.token);
                    this.props.history.push('/')
                } else {
                    console.log("TA ERRADO IRMAO")

                }
            })
            .catch(erro => {
                this.setState({ erro: "Usuário ou senha inválidos" });
                console.log(erro);
            })
    }
    render() {
        return (
            <div>
                <header className="menuzao">
                    <nav className="menu">
                        <ul>
                            <li id="menuzin">
                                <h1>OPFLIX</h1>
                                <a href="/">Início</a>
                                <Link to='/login'>Login</Link>
                                <Link to='/lancamentos'>Lançamentos</Link>
                                <Link to='/categorias'>Categorias</Link>
                            </li>
                        </ul>
                    </nav>
                </header>
                <section className="cadastroLogin">
                    <div className="formulario-login">
                        <form onSubmit={this.fazerLogin}>
                            <div className="item">
                                <input
                                    placeholder="E-Mail"
                                    type="text"
                                    onChange={this.setarEstadoEmail}
                                    value={this.state.email}
                                />
                            </div>
                            <div className="item">
                                <input
                                    className="input__login"
                                    placeholder="Senha"
                                    type="password"
                                    onChange={this.setarEstadoSenha}
                                    value={this.state.senha}
                                />
                            </div>
                            <div className="item">
                                <button className="btn btn__login" id="btn__login">
                                    Login
                </button>
                            </div>
                            <p className="text__login">
                                {this.state.erro}
                            </p>
                        </form>
                    </div>
                </section>
                <footer id="rodape2">
                    <p>redes sociais: blablabla@gmail.com</p>
                    <p>facebook: opflix series official</p>
                    <p>Todos os direitos reservados</p>
                </footer>
            </div>
        )
    }
}