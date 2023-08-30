import React, { useState, useEffect } from 'react';
import './Slider2.css';

const Slider2 = () => {
  const images = [
    'https://www.martidergisi.com/wp-content/uploads/2011/03/manzara-3.jpg',
    'https://www.ekoyapidergisi.org/images/cevre_1528110114.jpg',
    'https://www.martidergisi.com/wp-content/uploads/2011/03/manzara-3.jpg',
  ];

  const [currentImageIndex, setCurrentImageIndex] = useState(0);

  const prevSlide = () => {
    setCurrentImageIndex(prevIndex => (prevIndex === 0 ? images.length - 1 : prevIndex - 1));
  };

  const nextSlide = () => {
    setCurrentImageIndex(prevIndex => (prevIndex === images.length - 1 ? 0 : prevIndex + 1));
  };

  useEffect(() => {
    const interval = setInterval(() => {
      nextSlide();
    }, 3000); 

    return () => {
      clearInterval(interval);
    };
  }, [currentImageIndex]);

  return (
    <div className="slider-container">
      <div className="slider">
        {images.map((imageUrl, index) => (
          <div
            key={index}
            className={index === currentImageIndex ? 'slide active' : 'slide'}
            style={{ backgroundImage: `url(${imageUrl})` }}
          ></div>
        ))}
      </div>
      <button className="prev-button" onClick={prevSlide}>
        &lt;
      </button>
      <button className="next-button" onClick={nextSlide}>
        &gt;
      </button>
    </div>
  );
};

export default Slider2;
