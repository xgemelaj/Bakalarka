Instalacia Latexu
=================

  pod Linuxom Debian/Ubuntu (s Windowsom skusenosti zial nemam):

      sudo apt-get install texlive-latex3 texlive-lang-czechslovak texlive-latex-recommended lmodern texlive-latex-extra latex-xcolor texlive-fonts-extra texlive-fonts-recommended texlive-generic-recommended



Vygenerovanie pdf z tex suborov
===============================

  Pre spravne vygenerovanie kompletneho pdf-ka je IMO nutne spustit:
      - 2x pdflatex
      - 2x bibtex
      - 2x pdflatex

  ...konkretne napr. v linuxe mam otestovany prikaz:

      pdflatex main.tex; pdflatex main.tex; bibtex main; bibtex main; pdflatex main.tex; pdflatex main.tex;

  - tento prikaz vytvori subor main.pdf (a okrem neho este kopec vseliakych zbytocnych logov a inych pomocnych suborov)



Obrazky
=======

  - vlozime ich do priecinka figures/




Snad pomoze :)
mnicky
