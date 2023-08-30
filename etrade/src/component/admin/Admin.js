import React, { useState } from 'react';
import AddCategory from '../category/AddCategory';
import AddSupplier from '../supplier/AddSupplier';
import AddProduct from '../product/AddProduct';
import { ToastContainer, toast } from 'react-toastify';

function Admin() {
  const [currentStep, setCurrentStep] = useState('addSupplier');

  const handleNextStep = () => {
    switch (currentStep) {
      case 'addSupplier':
        setCurrentStep('addCategory');
        break;
      case 'addCategory':
        setCurrentStep('addProduct');
        break;
      case 'addProduct':
        toast.success('Tüm adımlar tamamlandı!');
        break;
      default:
        break;
    }
  };

  const handlePreviousStep = () => {
    switch (currentStep) {
      case 'addCategory':
        setCurrentStep('addSupplier');
        break;
      case 'addProduct':
        setCurrentStep('addCategory');
        break;
      default:
        break;
    }
  };

  const renderStep = () => {
    switch (currentStep) {
      case 'addSupplier':
        return <AddSupplier onNextStep={handleNextStep} />;
      case 'addCategory':
        return <AddCategory onNextStep={handleNextStep} />;
      case 'addProduct':
        return <AddProduct onNextStep={handleNextStep} />;
      default:
        return null;
    }
  };

  return (
    <div className='container md-2'>
      <div className='container '>
        <button onClick={handlePreviousStep}>Geri</button>
        <button onClick={handleNextStep}>İleri</button>
      </div>
      {renderStep()}
   
      <ToastContainer />
  
    </div>
  );
}

export default Admin;
