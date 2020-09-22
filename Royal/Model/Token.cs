using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Royal.Model
{
    class Token
    {
        private string tokenType;
        private Boolean ifToken;
        private Boolean ifRoseta;
        private Color color;
        private Image imageButton;

        public Token(string tokenType, bool ifToken, bool ifRoseta, Color color, Image imageButton)
        {
            this.tokenType = tokenType;
            this.ifToken = ifToken;
            this.ifRoseta = ifRoseta;
            this.color = color;
            this.imageButton = imageButton;
        }

        public void setTokenType(string tokenType) {
            this.tokenType = tokenType;
        }

        public string getTokenType() {
            return this.tokenType;
        }

        public void setIfToken(Boolean ifToken)
        {
            this.ifToken = ifToken;
        }

        public Boolean getIfToken()
        {
            return this.ifToken;
        }

        public void setIfRoseta(Boolean ifRoseta)
        {
            this.ifRoseta = ifRoseta;
        }

        public Boolean getIfRoseta()
        {
            return this.ifRoseta;
        }

        public void setColor(Color color) {
            this.color = color;
        }

        public Color getColor() {
            return this.color;
        }

        public void setImage(Image image) {
            this.imageButton = image;
        }

        public Image getImage() {
            return this.imageButton;
        }
    }
}
