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

        fetch('http://192.168.4.183:5000/api/Usuario', {
            method: "POST",
            body: JSON.stringify({
                nome: this.state.nome,
                email: this.state.email,
                senha: this.state.senha,
            }),
            headers: {
                'Accept': 'application/json',
                "Content-Type": "application/json"
            }
        })
            .catch(erro => console.log(erro))
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
                                <Link to='/localizacoes'>Localizacoes</Link>
                            </li>
                        </ul>
                    </nav>
                </header>
                <div className="formulario-cadastro">
                    <form onSubmit={this.cadastrarUsuario}>
                        <input type="text" placeholder="Insira seu nome" value={this.state.nome} onChangeText={ nome => this.setState({ nome })} />
                        <input type="text" placeholder="Email" value={this.state.email} onChangeText={ email => this.setState({ email })} />
                        <input type="password" placeholder="Senha(No mínimo 4 digitos ex:1234)" value={this.state.senha} onChangeText={senha => this.setState({ senha })} />
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