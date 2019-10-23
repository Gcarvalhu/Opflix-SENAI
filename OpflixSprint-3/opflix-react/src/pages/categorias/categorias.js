import React, { Component } from "react";
import Axios from "axios";
import { Link } from "react-router-dom";

import '../../assets/css/categorias.css';

export default class Categorias extends Component {
    constructor() {
        super();
        this.state = {
            lista: [],
            nome: "",
        }
    }

    componentDidMount() {
        this.listarCategorias();
    }

    listarCategorias = () => {

        var config = {
            headers: { 'Authorization': "bearer " + localStorage.getItem("usuario-opflix") }
        };

        Axios.get('http://localhost:5000/api/categoria',
            config
        ).then((response) => {
            this.setState({ lista: response.data })
        })
        console.log(this.state.lista)
    }
    Logout() {
        localStorage.clear();
        window.location.href = '/';
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
                                <Link to='/lancamentos'>Lançamentos</Link>
                            </li>
                        </ul>
                    </nav>
                </header>
                <section>

                    <h1 className="titulo-sections">Categorias</h1>
                    <table id="tabelinha">
                        <thead>
                            <tr>
                                <th>Nome:</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.lista.map(element => {
                                return (
                                    <tr key={element.idCategoria}>
                                        <td className="linhaTabela">{element.nomeCategoria}</td>
                                    </tr>
                                );
                            })}
                        </tbody>
                    </table>
                </section>
                <footer id="rodape2">
                    <p>redes sociais: blablabla@gmail.com</p>
                    <p>facebook: opflix series official</p>
                    <p>Todos os direitos reservados</p>
                </footer>
            </div>
        );
    }
}