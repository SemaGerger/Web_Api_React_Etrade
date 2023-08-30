import React, { Component } from 'react';
import axios from 'axios';

class BasketDetail extends Component {
  constructor(props) {
    super(props);
    this.state = {
      basketItems: [], // Sepet içeriğini tutacak state
    };
  }


  componentDidMount() {
    this.fetchBasketItems();
  }

  fetchBasketItems = () => {
    axios.get('https://localhost:7203/api/BasketDetail/List')
      .then(response => {
        console.log('Basket Items:', response.data);
        this.setState({ basketItems: response.data });
      })
      .catch(error => {
        console.error('API request error:', error);
      });
  };

  handleRemoveFromBasket = (basketId, productId) => {
    axios.delete(`https://localhost:7203/api/BasketDetail/Remove?basketId=${basketId}&productId=${productId}`)
      .then(response => {
        console.log('Item removed from basket:', response.data);
        this.fetchBasketItems(); // Sepet içeriğini güncelle
      })
      .catch(error => {
        console.error('API request error:', error);
      });
  };
  calculateTotalPrice = () => {
    const { basketItems } = this.state;

    let totalPrice = 0;
    basketItems.forEach(item => {
      totalPrice += item.unitPrice * item.amount;
    });

    return totalPrice;
  };

  render() {
    const { basketItems } = this.state;

    return (

      <>
        <section className='page'>
          <div className='shopping-cart dark'>
            <div className='container'>


              {/* header */}
              <div className="card-header py-3 block-heading">
                <h2 className="mb-0">Shopping Card - {basketItems.length} items</h2>
              </div>

              {/* products and summary*/}
              <div className='content'>
                <div className="row">

                  {/* Products */}
                  <div className='col-md-12 col-lg-8'>
                    <div className='items'>
                      <div className='product'>
                        {basketItems.map(item => (
                          <div className='row' key={item.id}>
                            {/* image */}
                            <div className='col-md-3'>
                              <img src={item.photoUrl} className='img-fluid mx-auto d-block image py-3 rounded-top-5 rounded-bottom-5' alt={item.description} />
                            </div>
                            {/* product*/}
                            <div className='col-md-8 py-3'>
                              <div className='info'>
                                {/* product name, info */}
                                <div className='row'>
                                  {/* product name */}
                                  <div className='col-md-5 product-name'>
                                    <div className='product-name'>
                                      <strong>{item.description}</strong>
                                      <div class="product-info">
                                        <h8>Yurtiçi Kargo</h8>
                                      </div>
                                    </div>
                                  </div>
                                  {/* product quantity */}
                                  <div className='col-md-4 quantity'>
                                    <input id="form1" min="0" name="quantity" value={item.amount} type="number" className="form-control" />
                                    <label className="form-label" htmlFor="form1">Quantity</label>
                                  </div>
                                  {/* product price */}
                                  <div class="col-md-3 price">
                                    <span>{item.unitPrice}₺</span>
                                    <button type="button" className="btn btn-primary btn-sm me-1 mb-2" data-mdb-toggle="tooltip" title="Remove item" onClick={() => this.handleRemoveFromBasket(item.basketId, item.productId)}>
                                      <i className="fas fa-trash"></i> Remove
                                    </button>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        ))}
                      </div>
                    </div>
                  </div>
                  
                  {/* summary */}
                  <div className="card col-md-12 col-lg-4">
                    <div className="card-header py-3">
                      <h5 className="mb-0">Summary</h5>
                    </div>
                    {/* summary body */}
                    <div className="card-body">
                      <ul className="list-group list-group-flush">
                        <li className="list-group-item d-flex justify-content-between align-items-center border-0 px-0 pb-0 ">
                          <strong > <span>Total Price</span> </strong>
                        </li>
                        {/* total body */}
                        <div className="card-body">

                          <li className="list-group-item d-flex justify-content-between align-items-center border-0 px-2 pb-0">
                            <strong > Product </strong>
                            <span>  {basketItems.length} </span>
                          </li>
                          <li className="list-group-item d-flex justify-content-between align-items-center px-2">
                            <strong > Shipping </strong>
                            <span>Paid by seller</span>
                          </li>
                          <li className="list-group-item d-flex justify-content-between align-items-center border-0 px-0 mb-3">
                            <strong>Total</strong>
                            <p className="mb-0">(including VAT)</p>
                            <span><strong>${this.calculateTotalPrice().toFixed(2)}</strong></span>
                          </li>
                        </div>
                        <button type="button" className="btn btn-primary btn-lg btn-block">
                          Go to checkout
                        </button>
                      </ul>
                    </div>
                  </div>
                </div> {/* row end */}
              </div>  {/* content end */}
            </div>  {/* container */}
          </div> {/* shopping-cart */}
        </section>
      </>
    );
  }
}

export default BasketDetail;