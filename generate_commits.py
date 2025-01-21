import datetime

def generate_svg(commits_file):
    svg_lines = []
    svg_width = 600
    svg_height = 400
    y_pos = 50
    svg_lines.append(f'<svg width="{svg_width}" height="{svg_height}">')
    svg_lines.append('<rect width="100%" height="100%" fill="lightblue" />')
    svg_lines.append('<text x="20" y="30" font-size="20">Commit History</text>')

    with open(commits_file, 'r') as f:
      for commit_data in f:
          parts = commit_data.strip().split('\x1f')
          if len(parts) >= 3:
              date, hash, message = parts[0], parts[1], parts[2].split('\n')[0]
              date_obj = datetime.datetime.strptime(date, '%d.%m.%Y')
              date_str = date_obj.strftime('%d %b %Y')
              svg_lines.append(f'<circle cx="50" cy="{y_pos}" r="10" fill="darkgreen" />')
              svg_lines.append(f'<text x="80" y="{y_pos + 5}" font-size="12">{date_str} - {hash}</text>')
              wrapped_message = wrap_text(message, 70)
              for i, line in enumerate(wrapped_message):
                  svg_lines.append(f'<text x="80" y="{y_pos + 20 + (i*15)}" font-size="10">{line}</text>')
              y_pos += 35 + (len(wrapped_message) * 15)

    svg_lines.append('</svg>')
    return '\n'.join(svg_lines)

def wrap_text(text, width):
    words = text.split()
    lines = []
    current_line = ""
    for word in words:
        if len(current_line + " " + word) <= width:
            if current_line:
                current_line += " "
            current_line += word
        else:
            lines.append(current_line)
            current_line = word
    lines.append(current_line)
    return lines

if __name__ == "__main__":
    svg_content = generate_svg("commits.txt")
    with open("commits.svg", "w") as f:
        f.write(svg_content)
