import React, { Component } from "react";

import { Link } from "react-router-dom";

import '../../assets/css/cadastro.css';
class Cadastro extends Component {
    constructor() {
        super();
        this.state = {
            lista: [],
            nome: "",
            email: "",
            senha: "",
        }
    }

    cadastrarUsuario = (event) => {
        event.preventDefault();

        fetch('http://localhost:5000/api/Usuario', {
            method: "POST",
            body: JSON.stringify({
                nome: this.state.nome,
                email: this.state.email,
                senha: this.state.senha,
            }),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .catch(erro => console.log(erro))
    }
    nomeUsuario = (event) => {
        this.setState({ nome: event.target.value });
        console.log(this.state);
    }
    emailUsuario = (event) => {
        this.setState({ email: event.target.value });
        console.log(this.state);
    }
    senhaUsuario = (event) => {
        this.setState({ senha: event.target.value });
        console.log(this.state);
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
                                <a href="/" onClick={this.Logout}>LOGOUT</a>
                                <Link to='/categorias'>Categorias</Link>
                            </li>
                        </ul>
                    </nav>
                </header>
                <div className="formulario-cadastro">
                    <form onSubmit={this.cadastrarUsuario}>
                        <input type="text" placeholder="Insira seu nome" value={this.state.nome} onChange={this.nomeUsuario} />
                        <input type="text" placeholder="Email" value={this.state.email} onChange={this.emailUsuario} />
                        <input type="password" placeholder="Senha(No mínimo 4 digitos ex:1234)" value={this.state.senha} onChange={this.senhaUsuario} />
                        <button onClick={this.cadastrarUsuario}>Cadastrar</button>
                    </form>
                </div>
                <footer id="rodape2">
                    <p>redes sociais: blablabla@gmail.com</p>
                    <p>facebook: opflix series official</p>
                    <p>Todos os direitos reservados</p>
                </footer>
            </div>
        );
    }
}

export default Cadastro;