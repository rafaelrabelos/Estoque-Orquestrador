import React from "react";
import Paper from '@material-ui/core/paper';
import { ObtemProdutos } from 'Fluxos/Produto/ProdutoController';
import ProdutoItemComp from 'views/ComponentesComuns/ProdutoItemComp';
import CollapseItem from 'views/ComponentesComuns/CollapseItem';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Spinner, Button, Card, CardHeader, CardBody, Row, Col, Container, Input} from "reactstrap";
import { SalvaProduto } from 'Fluxos/Produto/ProdutoController';
toast.configure({ autoClose: 4000 });


class Home extends React.Component {

  constructor(props) {
    super(props);

    this.state = {
        ListaProdutosComponente: <Spinner type="grow" />,
        ProdutoContent : <Spinner type="grow" />,
        CollapseIsOpen : false,
        NomeProduto : this.props.nome,
        QtdProduto : this.props.qtd,
        ValorProduto : this.props.valor
    };
  }

  salvarNovo = async () => {

    const {NomeProduto, QtdProduto, ValorProduto} = this.state;

    let result = await SalvaProduto( NomeProduto, QtdProduto, ValorProduto );

    if(result.status &&  result.resposta.length === 1 ){


        toast.success("Produto Gravado Com Sucesso!",
            {
                position: toast.POSITION.BOTTOM_RIGHT,
                onClose: () =>{ this.toggle(); this.componentDidMount() }
            });
    }

    console.log(result)
}

  onChangeInput = (e) => this.setState({  [e.target.name]: e.target.value } ) 

  toggle = () =>{  this.setState({ CollapseIsOpen : !this.state.CollapseIsOpen } )}


    componentDidMount = async() => {

    let produtos = await ObtemProdutos();

    console.log(produtos);

    if( produtos.status ){
       let lista =  produtos.resposta.map( item => 
        <ProdutoItemComp
        key={item.id}
        ItemKey={item.id}
        nome={item.nome}
        id={item.id}
        valor={item.valor}
        excluido={item.excluido}
        qtd={item.qtd} 
        />)

        this.setState({
            ListaProdutosComponente : lista
        })
    }

  }

  render() {
    return (
        <>
            {/* Page content */}
            <Container className=" mt--7" fluid>
                <Row>
                    <div className=" col">
                        <Card className=" shadow">
                            <CardHeader className=" bg-transparent"> <h3 className=" mb-0"> Produtos </h3></CardHeader>
                            <CardBody>
                                <br />
                                <Container style={{ marginLeft: 0, marginRight: 0 }} >
                                    <Row>
                                        <Col xs="8">
                                            <Button size="md" color="success" onClick={() => this.toggle()}> {this.state.CollapseIsOpen ? "Cancelar":"Adicionar"}</Button>
                                        </Col>
                                    </Row>
                                    <CollapseItem isOpen={this.state.CollapseIsOpen} >
                                        <br />
                                            <ul className="nav nav-tabs" id={"myTab_" + this.props.id} role="tablist">
                                                <li className="nav-item">
                                                    <a className="nav-link active" id={"basico-tab" + this.props.id}  data-toggle="tab" href={"#basico" + this.props.id}  role="tab" aria-controls="home" aria-selected="true">Adicionar</a>
                                                </li>
                                            </ul>
                                            <div className="tab-content" id="myTabContent">
                                                <div className="tab-pane fade show active" id={"basico" + this.props.id}  role="tabpanel" aria-labelledby={"basico-tab" + this.props.id} >
                                                    <Paper>
                                                        <Row>
                                                            <Col xs="6" md="6">
                                                                <Input 
                                                                    bsSize="sm"
                                                                    type="text"
                                                                    id={this.props.id + "_nam"}
                                                                    name="NomeProduto"
                                                                    placeholder="Nome Produto"
                                                                    value={ this.state.NomeProduto }
                                                                    onChange={(e) => this.onChangeInput(e) } 
                                                                />
                                                                <Input 
                                                                    bsSize="sm"
                                                                    type="text"
                                                                    id={this.props.id + "_qtd"}
                                                                    name={"QtdProduto"}
                                                                    placeholder="Qtd Produto"
                                                                    value={ this.state.QtdProduto}
                                                                    onChange={(e) => this.onChangeInput(e) } 
                                                                />
                                                                <Input 
                                                                    bsSize="sm"
                                                                    type="text"
                                                                    id={this.props.id + "_val"}
                                                                    name={"ValorProduto"}
                                                                    placeholder="Valor Produto"
                                                                    value={ this.state.ValorProduto }
                                                                    onChange={(e) => this.onChangeInput(e) } 
                                                                />
                                                                </Col>
                                                                <Col xs="4" md="4">
                                                                    <br />
                                                                    <Button size="sm" color="warning" onClick={() => this.toggle() }>cancelar</Button>
                                                                    <Button size="sm" color="success" onClick={() => this.salvarNovo()}>salvar</Button>
                                                                </Col>
                                                        </Row>
                                                    </Paper>
                                                </div>

                                            </div>
                                        </CollapseItem>
                                </Container>
                                <br />
                                <Paper id="paperTaxas" >  { this.state.ListaProdutosComponente } </Paper>
                            </CardBody>
                        </Card>
                    </div>
                </Row>
            </Container>
        </>
    );
  }
}

export default Home;
